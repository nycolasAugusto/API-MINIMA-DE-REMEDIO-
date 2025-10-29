const formulario = document.getElementById("formRemedio");
const url = "http://localhost:5282/remedios";



document.addEventListener("DOMContentLoaded", () => {


    formulario.addEventListener("submit", async (e) => {
        e.preventDefault();

        const remedio = {
            nomeRemedio: document.getElementById("nomeRemedio").value,
            dataValidade: document.getElementById("dataValidade").value,
            miligramas: document.getElementById("miligramas").value,
            valor: document.getElementById("valor").value,
            marca: document.getElementById("marca").value,

        };



        try {
            const response = await fetch(url, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(remedio)

            });

            if (!response.ok) {
                const errText = await response.text();
                throw new Error(errText || "Erro ao cadastrar o remedio");
            }

            const data = await response.json();
            alert(`remedio cadastrado com sucesso! ID: ${data.Id}`);
            formulario.reset();
        } catch (error) {
            alert(" X " + error.message);
            console.error("Erro ao cadastrar remedio:", error);

        }
    }
)})
