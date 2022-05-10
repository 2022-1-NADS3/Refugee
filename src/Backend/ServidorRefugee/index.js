var express = require("express");
var app = express();
var port = process.env.PORT || 3000;
var hostname = "localhost";
const json ='[{"nome":"antonio","sobrenome":" Carlos","altura":1.79},{"nome":"dego","sobrenome":" cardoso","altura":1.78}]';
var objeto = JSON.parse(json);
var bodyParser = require('body-parser')

app.use(bodyParser.json('application/json'));

app.get("/", function(req,res){
    var nome = req.query.nome;
    res.send("Olá pessoa!"+objeto[0].nome+objeto[1].sobrenome+objeto[0].altura);
    console.log("Passei aqui!");
});

app.get("/teste1", function(req,res){
    res.send("<h1>Carai cuzão<h1>");
})

app.get("/user", function(req,res){
    console.log("Enviei po Get");
    res.send(JSON.stringify({
        nome:"Teo",
        sobrenome:"balão",
        idade:22,
        altura:1.75
    }));
});

app.post("/add", function(req,res){
    console.log("recebi um dado!")
    console.log(req.body.nome);
    console.log(req.body.sobrenome);
    console.log(req.body.idade);
    console.log(req.body.altura);
    res.send("JSON Recebido!")
});

app.listen(port, hostname, () => {
    console.log("Servidor http//"+hostname+":"+port);
});