const formDelete = document.getElementById("formDelete");
const selectRemedio = document.getElementById("selectRemedio");
const resultadoDelete = document.getElementById("resultadoDelete"); // (Adicionei este que 

const urlGetALL = "http://localhost:5282/remedios"; 


// --- 2. CARREGAR A LISTA (GET ALL) ---

/**
 * Busca todos os remédios na API e preenche o <select>
 */
async function carregarRemedios() {
    innerText = "";
       try {
        const response = await fetch(urlGetALL); 
        const listaDeRemedios = await response.json(); 

        listaDeRemedios.forEach(remedio => {
            
            const option = document.createElement("option");

            
            option.value = remedio.id;

            
            option.innerText = remedio.nomeRemedio; 

          
            selectRemedio.appendChild(option);
        });

    } catch (error) {
        console.error("Erro ao carregar remédios:", error);
        
        selectRemedio.innerHTML = "<option value=''>Erro ao carregar</option>";
    }
}

formDelete.addEventListener("submit" ,  (event)=>{
    event.preventDefault();
    const idParaDeletar = selectRemedio.value;
    console.log("id escolhido = "  + idParaDeletar);
})

document.addEventListener("DOMContentLoaded", carregarRemedios);