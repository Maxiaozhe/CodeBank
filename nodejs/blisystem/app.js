'use strict';
try {
    const debug = require('debug');
    const unitTest = require('./test/UnitTest');
    const express = require('express');
    const config = require('./config/config');
    const webSocket = require('./control/wsserver');
    const path = require('path');
    const favicon = require('serve-favicon');
    const logger = require('morgan');
    const cookieParser = require('cookie-parser');
    const bodyParser = require('body-parser');
    const wsPool = [];
    //var vision = require("./control/visionControl");
    //vision.detectAll("./public/upload/IMG-1532402434123.jpg");
    //var multer = require("multer");
    //var uploader = multer({ dest: './public/upload/' });
    //const routes = require('./routes/index');
    //const users = require('./routes/users');
    const sdServer = require('./routes/sdServer');
    const iwbServer = require('./routes/iwbServer');
    const upload = require("./routes/upload");

    const app = express();


    //UnitTest
    //unitTest.test();

    console.log(process.argv);

    // view engine setup
    app.set('views', path.join(__dirname, 'views'));
    app.set('view engine', 'pug');

    // uncomment after placing your favicon in /public
    //app.use(favicon(__dirname + '/public/favicon.ico'));
    app.use(logger('dev'));
    app.use(bodyParser.json());
    app.use(bodyParser.urlencoded({ extended: false }));
    app.use(cookieParser());
    app.use(express.static(path.join(__dirname, 'public')));
    //app.use(uploader.single('file');

    app.use('/', sdServer);
    app.use("/iwb", iwbServer);
    app.use('/upload', upload.router);
    //app.use('/users', users);

    // catch 404 and forward to error handler
    app.use(function (req, res, next) {
        var err = new Error('Not Found');
        err.status = 404;
        next(err);
    });

    // error handlers

    // development error handler
    // will print stacktrace
    if (app.get('env') === 'development') {
        app.use(function (err, req, res, next) {
            res.status(err.status || 500);
            res.render('error', {
                message: err.message,
                error: err
            });
        });
    }

    // production error handler
    // no stacktraces leaked to user
    app.use(function (err, req, res, next) {
        res.status(err.status || 500);
        res.render('error', {
            message: err.message,
            error: {}
        });
    });



    app.set('port', config.HPPT_PORT || 8080);

    var server = app.listen(app.get('port'), function () {
        debug('Express server listening on port ' + server.address().port);
    });

    //Websocket server start
    const wss = webSocket.create(server, wsPool, config.WS_PATH);
    upload.setWebSocket(wsPool);
    console.log(process);
    console.log("start!!!");
} catch (ex) {
    console.log(ex);
}
