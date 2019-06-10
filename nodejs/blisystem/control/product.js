'usr strict';
var db = require("./database");
var Product = /** @class */ (function () {
    function Product(id, name, category, content, condition, url) {
        this.id = id;
        this.name = name;
        this.category = category;
        this.content = content;
        this.condition = condition;
        this.url = url;
    }
    return Product;
}());

Product.prototype.insert = function (client, callback) {
    let sql = "INSERT INTO product_master(id, name, category, content, condition, url) "
        + "values($1,$2,$3,$4,$5,$6)";
    let values = [this.id, this.name, this.category, this.content, this.condition, this.url];
    db.query(client, sql, values,callback);
};
module.exports = Product;

