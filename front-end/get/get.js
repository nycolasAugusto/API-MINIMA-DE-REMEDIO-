const formGetPorId = document.getElementById("formGetPorId");
const resultadoBusca = document.getElementById("resultadoBusca");
const remedioDetalhes = document.getElementById("remedioDetalhes");
const paragrafo = document.getElementById("paragrafo");

formGetPorId.addEventListener("submit", async (event) => {

    event.preventDefault();
    const idRecebido = document.getElementById("remedioId").value;
    paragrafo.innerText = "Busca por ID ";

    if (!idRecebido) {
        alert("Por favor, digite um ID.");
        return;
    }

    try {
        // Crases (``) permitem que ${...} insira o valor da variável
        const response = await fetch(`http://localhost:5282/remedios/${idRecebido}`);

        if (response.status == 404) {
            throw new Error("Remedio nao encontrado");

        }
        if (!response.ok) {
            throw new Error("Erro ao buscar remédio: " + response.statusText);
        }

        const remedio = await response.json();

        remedioDetalhes.textContent = JSON.stringify(remedio, null, 2);
        resultadoBusca.style.display = "block";



    } catch (error) {
        console.error("Falha ao buscar por ID:", error);
        // Exibe o erro
        remedioDetalhes.textContent = `Erro: ${error.message}`;
        resultadoBusca.style.display = "block";
    }








});




const formGetTodos = document.getElementById("formGetTodos");
const corpoTabela = document.getElementById("corpoTabela");


formGetTodos.addEventListener("submit", (event) => {
    event.preventDefault();


    corpoTabela.innerHTML = "";


    fetch("http://localhost:5282/remedios").
        then((response) => response.json())
        .then((listaDeRemedios) => {

            listaDeRemedios.forEach(remedio => {

                const linha = document.createElement("tr");


                linha.innerHTML = `
             <td>${remedio.id}</td>
            <td>${remedio.nomeRemedio}</td>
            <td>${remedio.marca}</td>
            <td>${remedio.miligramas}</td>
            <td>${remedio.dataValidade}</td> 
            <td>${remedio.valor}</td>
            `;

                corpoTabela.appendChild(linha);


            });
        })
});

