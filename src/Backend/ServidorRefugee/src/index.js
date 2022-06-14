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
})

/* --------------------------
Api de inserção de dados no banco de dados
----------------------------- */
app.post('/cadastrar_refugiados', async (req, res) => {
    const { refuname, refusexo, refupais, refuidioma,  refuestadoCivil, refunumeroFilhos, refutelefone, refudeficiencia, refuemail, refusenha} = req.body  
    let user = ''
    try {
        user = await pool.query('SELECT * FROM cadRefugiado WHERE nome_refugiado = ($1)', [refuname])
        if(!user.rows[0]) {
            user = await pool.query('INSERT INTO cadRefugiado(nome_refugiado, sexo_refugiado, pais_refugiado, idioma_refugiado, estadoCivil_refugiado, numeroFilhos_refugiado, telefone_refugiado, deficiencia_refugiado, email_refugiado, senha_refugiado) VALUES ($1, $2, $3, $4, $5, $6, $7, $8, $9, $10) RETURNING *', [refuname, refusexo, refupais, refuidioma,  refuestadoCivil, refunumeroFilhos, refutelefone, refudeficiencia, refuemail, refusenha])
        }
        return res.status(200).send(user.rows)
    } catch(err) {
        return res.status(400).send(err)
    }
})

app.listen(PORT, () => console.log(`Server runnig on port ${PORT}`))