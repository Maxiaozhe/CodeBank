/*環境設定*/
module.exports = {
    /*画像ファイルの保存環境*/
    uploadPath: './public/upload/',
    APIKEY: "AIzaSyBL6NtX1XlJKS547PZ9OEHRtt-tP_d9pxo",
    ServiceAccountKey: "9c2dcb0629ce7c664728b1063dd003ce3808262a",
    WS_HOST:"ws://10.11.200.60",
    WS_PATH: "/ws", //resive client(IWB側)
    HPPT_PORT:"80",
    postgreSql: {
        user: 'postgres',
        password: 'postgres',
        host: 'localhost',
        database: 'BILDB',
        port: 5432,
        schema: "BIL"
    }
};