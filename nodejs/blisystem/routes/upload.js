'use strict';
const express = require("express");
const multer = require("multer");
const config = require("../config/config");
const path = require("path");
const router = express.Router();
const visionApi = require("../control/visionApi");
let clients;



var storage = multer.diskStorage({
    destination: function (req, file, cb) {
        cb(null, config.uploadPath);
    },
    filename: function (req, file, cb) {
        let orgname = file.originalname;
        let ext = path.extname(orgname);
        let filename = "IMG-" + Date.now() + ext;
        switch (ext.toLowerCase()) {
            case ".jpg":
            case ".jpeg":
            case ".gif":
            case ".png":
                cb(null, filename);
                break;
            default:
                cb(Error('ファイル形式不正'), filename);
                break;
        }

    }
});

var uploader = multer({
    storage: storage
});
/*Get Client Page*/
router.post('/', uploader.single('file'), function (req, res, next) {
    if (req.file) {
        let filename = req.file.filename;
        let orgname = req.file.originalname;
        let clientID = req.param('clientID');
        let wslist = getWebSockets(clientID);
        visionApi.detectImage(`./public/upload/${filename}`, wslist);
        res.send('POST OK' + orgname);
    }
});

function getWebSockets(clientID) {
    let wslist = clients.filter(x => x.id === clientID || x.type === 'iwb');
    return wslist;
}

module.exports = {
    router: router,
    setWebSocket: function (wsPool) {
        clients = wsPool;
    }
};
