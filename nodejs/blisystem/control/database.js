'use strict';
var config = require("../config/config");
var { Pool } = require("pg");
var analysis = require("../control/resultAnalysis");
var db = new Pool(config.postgreSql);

function connect() {
    return db.connect();
}
/**
 * Quetyを実行する
 * @param {PoolClient} client PoolClient(connectのcallbackで取得する)
 * @param {string} sql sql文
 * @param {Array} params　parameter
 * @param {function} callback callback(err,res)
 */
function query(client, sql, params, callback) {
    var setpath = `set search_path to "${config.postgreSql.schema}";`;
    client.query(setpath).then(res => {
        let qy = params ? client.query(sql, params) : client.query(sql);
        qy.then(res => {
            callback( null, res);
        }).catch(err => {
            callback(err);
        });
    }).catch(err => {
        callback(err);
    });

   
}

/**
 * テキスト検索
 * @param {PoolClient} client PoolClient(connectのcallbackで取得する)
 * @param {string[]} queryWords 検索キーワード
 * @param {function} callback callback(err,result)
 */
function queryContent(client, queryWords, callback) {
    let sqls = [];
    sqls.push('SELECT');
    sqls.push('    ts_rank(a.tsvector, to_tsquery($1)) as rank,a.name,a.category,a.content,a.url');
    sqls.push('From');
    sqls.push('(');
    sqls.push(' SELECT');
    sqls.push(' id, url, name, category, content,');
    sqls.push(" setweight(to_tsvector(lower(name)), 'A') || setweight(to_tsvector(lower(category)), 'B') || setweight(to_tsvector(lower(content)), 'C') as tsvector");
    sqls.push(" FROM");
    sqls.push("  product_master");
    sqls.push(" ) as a WHERE a.tsvector@@to_tsquery($2)");
    sqls.push(" order by ts_rank(a.tsvector, to_tsquery($1)) desc");
    let andQuery = queryWords.join('&');
    let orQuery = queryWords.join('|');
    query(client, sqls.join("\n"), [andQuery, orQuery], callback);
}


module.exports = {
    connect: connect,
    query: query,
    queryContent: queryContent
};