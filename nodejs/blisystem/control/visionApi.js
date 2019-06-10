'use strict';

const fs = require('fs');
const path = require('path');
const request = require('request');
const config = require('../config/config');
const analysis = require('../control/resultAnalysis');
const db = require('../control/database');
const apiKey = config.APIKEY;   
const maxResults = 100;

//if (process.argv.length < 3) {
//    console.log('Usage:');
//    console.log(`  node ${path.basename(process.argv[1])} <imagePath>`);
//    process.exit();
//}

/**
 * 画像認識を処理する
 * @param {string} imagePath 画像のパス
 * @param {WebSocket[]} wslist WebSocket
 */
function detectImage(imagePath, wslist) {
    const feature = 'TEXT_DETECTION';
    fs.readFile(imagePath, 'base64', (err, base64) => {
        if (err) {
            console.error(`file read errror: ${err}`);
            return;
        }
        const params = {
            requests: [
                {
                    image: {
                        content: base64
                    },
                    features: [
                        {
                            "type": "LABEL_DETECTION",
                            "maxResults": maxResults
                        },
                        {
                            "type": "WEB_DETECTION",
                            "maxResults": maxResults
                        },
                        {
                            "type": "LANDMARK_DETECTION",
                            "maxResults": maxResults
                        },
                        {
                            "type": "LOGO_DETECTION",
                            "maxResults": maxResults

                        },
                        {
                            "type": "TEXT_DETECTION"
                        },
                        {
                            "type": "DOCUMENT_TEXT_DETECTION"
                        },
                        {
                            "type": "TYPE_UNSPECIFIED"
                        }
                    ]
                    //,
                    //imageContext: {
                    //    languageHints: ['ja', 'en']
                    //}
                }
            ]
        };
        const data = JSON.stringify(params);
	//console.log(data);
        request.post({
            url: `https://vision.googleapis.com/v1/images:annotate?key=${apiKey}`,
            headers: {
                'Contetn-Type': 'Content-Type: application/json',
                'Content-Length': data.length
            },
            body: data
        },
            (err, res, body) => {
                if (err) {
                    console.error(`Cloud Vision API error: ${err}`);
                    return;
                }

                let resFilePath =
                    `${path.basename(imagePath, path.extname(imagePath))}.json`;
                let rawData = JSON.stringify(JSON.parse(body), null, 2);
                fs.writeFile(resFilePath, rawData, (err) => {
                    console.log(`result json write: ${resFilePath}`);
                });
                try {
                    let orgimgName =path.basename(imagePath);
                    let orgimg = `/upload/${orgimgName}`;
                    responseToWs(wslist, rawData, orgimg);
                } catch (ex) {
                    console.log(ex);
                }

            });
    });
}

function responseToWs(wslist,rawData,orgimg) {
    let json = JSON.parse(rawData);
    let result = analysis.filterResult(json);
    result.orgimg = orgimg;
    let sendData = JSON.stringify(result);
    let iwbClients = wslist.filter(ws => ws.type === 'iwb');
    let sdClient = wslist.filter(ws => ws.type === 'sd');
    //携帯側へ送信
    pushMessage(sdClient, sendData);
    //IWB側へ送信
    let queryWords = analysis.getQueryWords(result);
    db.connect().then(client => {
        db.queryContent(client,queryWords, function (err, res) {
            if (err) {
                pushMessage(iwbClients, JSON.stringify({ error: err }));
                return;
            }
            if (res && res.rowCount > 0) {
                let row = res.rows[0];
                pushMessage(iwbClients, JSON.stringify(row));
            }
            client.release();
        });
    });
   


}


/**
 * Websocket 側へ送信する
 * @param {any} wslist WebSocked client list
 * @param {any} sendData 送信データ
 */
function pushMessage(wslist, sendData) {
    if (wslist && wslist.length > 0) {
        wslist.forEach(x => {
            try {
                if (x.ws.readyState === 1) {
                    x.ws.send(sendData);
                    console.log("pushed!",sendData);
                }
            } catch (ex) {
                console.log(ex);
            }
        });
    }
}


module.exports = {
    detectImage: detectImage
};
