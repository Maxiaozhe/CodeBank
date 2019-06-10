
var config = require("../config/config");
var db = require("../control/database");
var Product = require("../control/product");
var path = require("path");
var fs = require('fs');
var analysis = require('../control/resultAnalysis');

function testDatabase() {
    testInsert();
    try {
        db.query("select * from product_master", function (err, result) {
            console.log(result.rows);
        });
    } catch (ex) {
        console.log(ex);
    }

}

function testInsert() {
    let product = new Product(1,
        "ricoh mp c8003",
        "product office office supplies printer",
        "Ricoh Multi-function printer Photocopier Printer Managed Print Services Printing Laser printing",
        "(ricoh&mp&c8003)&Ricoh&printer&Multi-function&Photocopier",
        "https://www.ricoh.co.jp/mfp/mp_c/8003_6503/");
    db.connect().then(client => {
        product.insert(client);
    });

}

function insertDatas() {
    console.log(process.cwd());
    console.log(process.execPath);
    var buffer = fs.readFileSync('./test/test_datas2.json','utf8');
    var datas = JSON.parse(buffer);
    // var datas = {
    //     "datas": [
    //         {
    //             "id": 1,
    //             "name": "T shirt printstart Garment Printer Ri100",
    //             "url": "https://rfgricoh.sharepoint.com/teams/sharepoint669/SitePages/Garment-Printer-Ri100.aspx",
    //             "result": "../IMG-1533520899894.json"
    //         },
    //         {
    //             "id": 2,
    //             "name": "DOUBLE",
    //             "url": "https://rfgricoh.sharepoint.com/teams/sharepoint669/SitePages/DOUBLE.aspx",
    //             "result": "../IMG-1533521293954.json"
    //         }
    //     ]
    // };
    // fs.writeFileSync('./test/test_datas2.json',JSON.stringify(datas));
    db.connect().then(client => {
        for (data of datas.datas) {
            let count = 0;
            let rawData = fs.readFileSync(data.result, { encoding: 'utf-8' });
            let json = JSON.parse(rawData);
            let resData = analysis.filterResult(json);
            let product = new Product(
                data.id,
                data.name,
                analysis.getCategory(resData),
                analysis.getQueryWords(resData).join(" "),
                '',
                data.url
            );
            product.insert(client, function () {
                count++;
                if (count === datas.datas.length) {
                    console.info(`画像登録完了しました。${count}件登録しました。)`)
                    client.release();
                }
            });
        }
    });
}

function testAnalysis() {
    var buffer = fs.readFileSync('IMG-1533028336205.json');
    var rawData = JSON.parse(buffer);
    var json = analysis.filterResult(rawData);
    var querywords = analysis.getQueryWords(json);
    db.connect().then(client => {
        db.queryContent(client, querywords, function (err, res) {
            if (err) {
                console.log(err);
            } else {
                console.log(res);
            }
        });
    });

}

module.exports = {

    test: function () {
        try {
            insertDatas();
           // testAnalysis();
            // testDatabase();
        } catch (ex) {
            console.log(ex);
            console.log(ex);
        }
    }

};

//insertDatas();