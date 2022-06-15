const express = require('express')
const cors = require('cors')
const { Pool } = require('pg')
require('dotenv').config()

const PORT = process.env.PORT || 3330 

const pool = new Pool({
    connectionString: process.env.POSTGRES_URL
})

const app = express()

app.use(express.json())
app.use(cors())

app.get('/',  (req, res) => {console.log('Olá mundo2')})
app.get('/users', async (req,res) => {
    try {
        const {rows} = await pool.query('SELECT * FROM teste')
        return res.status(200).send(rows)
    } catch(err) {
        return res.status(400).send(err)
    }
});

/* --------------------------
Api de inserção de dados no banco de dados do refugiado
----------------------------- */
app.post('/cadastrar_refugiados', async (req, res) => {
    const { refuname, refusexo, refupais, refuidioma,  refuestadoCivil, refunumeroFilhos, refutelefone, refudeficiencia, refuemail, refusenha} = req.body  
    let user = ''
    try {
        user = await pool.query('SELECT * FROM cadRefugiado WHERE email_refugiado = ($1)', [refuemail])
        if(!user.rows[0]) {
            user = await pool.query('INSERT INTO cadRefugiado(nome_refugiado, sexo_refugiado, pais_refugiado, idioma_refugiado, estadoCivil_refugiado, numeroFilhos_refugiado, telefone_refugiado, deficiencia_refugiado, email_refugiado, senha_refugiado) VALUES ($1, $2, $3, $4, $5, $6, $7, $8, $9, $10) RETURNING *', [refuname, refusexo, refupais, refuidioma,  refuestadoCivil, refunumeroFilhos, refutelefone, refudeficiencia, refuemail, refusenha])
        }
        return res.status(200).send(user.rows)
    } catch(err) {
        return res.status(400).send(err)
    }
});

app.post('/login_refugiado', async (req, res) => {
 
    const { refuemail, refusenha } = req.body
    console.log(refuemail,refusenha)
 try {
     const allTodos = await pool.query('SELECT * FROM cadRefugiado WHERE email_refugiado = ($1) AND senha_refugiado = ($2)', [refuemail, refusenha])
     return res.status(200).send(allTodos.rows[0])  
     } catch(err) {
         return res.status(400).send(err)
     }
 });

/* --------------------------
Api de inserção de dados no banco de dados do ong
----------------------------- */
app.post('/cadastrar_ongs', async (req, res) => {
    const { ongname, ongendereco, ongtelefone, ongresponsavel, ongservico, onghorario, ongcapacidade, onglinguas, ongemail, ongsenha } = req.body  
    let user = ''
    try {
        user = await pool.query('SELECT * FROM cadONG WHERE email_ong = ($1)', [ongemail])
        if(!user.rows[0]) {
            user = await pool.query('INSERT INTO cadONG(nome_ong, endereco_ong, telefone_ong, responsavel_ong, servico_ong, horarioAtendimento_ong, capacidadeDisponivel_ong, linguasAceitas_ONG, email_ong, senha_ong) VALUES ($1, $2, $3, $4, $5, $6, $7, $8, $9, $10) RETURNING *', [ongname, ongendereco, ongtelefone, ongresponsavel, ongservico, onghorario, ongcapacidade, onglinguas, ongemail, ongsenha])
        }
        return res.status(200).send(user.rows)
    } catch(err) {
        return res.status(400).send(err)
    }
});

app.post('/login_ongs', async (req, res) => {
 
    const { ongemail, ongsenha } = req.body
    console.log(ongemail,ongsenha)
 try {
     const allTodos = await pool.query('SELECT * FROM cadONG WHERE email_ong = ($1) AND senha_ong = ($2)', [ongemail, ongsenha])
     return res.status(200).send(allTodos.rows[0])
     } catch(err) {
         return res.status(400).send(err)
     }
 });

 
app.listen(PORT, () => console.log(`Server runnig on port ${PORT}`))