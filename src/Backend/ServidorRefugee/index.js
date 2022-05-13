var express = require("express");
var app = express();
var port = process.env.PORT || 3000;
//var hostname = "localhost";
const json ='[{"nome":"antonio","sobrenome":" Carlos","altura":1.79},{"nome":"dego","sobrenome":" cardoso","altura":1.78}]';
var objeto = JSON.parse(json);

app.get("/", function(req,res){
    var nome = req.query.nome;
    res.send("Olá pessoa!"+objeto[0].nome+objeto[1].sobrenome+objeto[0].altura);
    console.log("Passei aqui!");
});

app.get("/teste1", function(req,res){
    res.send("<h1>Carai cuzão<h1>");
})

app.listen(port, () => {
    console.log("Servidor http//"+port);
});

app.post("https://pure-ravine-77933.herokuapp.com/cadastro", function(req,res){
    
})