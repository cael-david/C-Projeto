document.addEventListener("DOMContentLoaded", function() {
    const lista = document.getElementById('materiais');
    const form = document.getElementById('materialForm');
    const mensagem = document.getElementById('mensagem');

    // Array local para simular materiais (sem backend)
    let materiais = [
        { nome: "Cimento", quantidade: 10, valor: 50.00 },
        { nome: "Areia", quantidade: 20, valor: 30.50 }
    ];

    function carregarMateriais() {
        lista.innerHTML = '';
        if (materiais.length > 0) {
            materiais.forEach(mat => {
                const li = document.createElement('li');
                li.innerHTML = `${mat.nome} (Qtd: ${mat.quantidade}) <span class="valor">R$ ${mat.valor.toFixed(2)}</span>`;
                lista.appendChild(li);
            });
        } else {
            lista.innerHTML = '<li>Nenhum material cadastrado.</li>';
        }
    }

    form.addEventListener('submit', function(e) {
        e.preventDefault();
        const nome = document.getElementById('nome').value.trim();
        const quantidade = parseInt(document.getElementById('quantidade').value);
        const valor = parseFloat(document.getElementById('valor').value);

        if (nome && quantidade > 0 && valor >= 0) {
            materiais.push({ nome, quantidade, valor });
            mensagem.textContent = "Material adicionado com sucesso!";
            mensagem.style.color = "green";
            form.reset();
            carregarMateriais();
        } else {
            mensagem.textContent = "Preencha os campos corretamente.";
            mensagem.style.color = "red";
        }
    });

    carregarMateriais();
});