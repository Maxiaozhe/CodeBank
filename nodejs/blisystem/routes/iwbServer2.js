
'use strict';
const express = require("express");
const router = express.Router();
const pug = require("pug");
const config = require("../config/config");

/*Get Client Page*/
router.get("/", function (req, res) {
    res.render('iwb2', {
        title: 'IWB画面',
        host: config.WS_HOST + config.WS_PATH
    });
});

module.exports = router;