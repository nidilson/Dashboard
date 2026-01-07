var pokemons = [];
document.addEventListener("DOMContentLoaded", async () => {
    let cardCont = document.getElementById("cards-container")

    await GetPokemon(getRandomIntInclusive(1, 151));    
    await GetPokemon(getRandomIntInclusive(1, 151));
    await GetPokemon(getRandomIntInclusive(1, 151));
    await GetPokemon(getRandomIntInclusive(1, 151));

    pokemons.forEach(pok => {
        let card = CreateCard(pok);
        cardCont.appendChild(card);
    })
});

async function GetPokemon(id) {
    await fetch(`/Home/Pokemon/${id}`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        }
    })
        .then(response => {
            let res = response.json();
            if (!response.ok) {
                throw new Error(res.message)
            }
            return res;
        })
        .then(data => {
            pokemons.push(data);
        })
        .catch(err => {
            alert(err.message);
        })
}
function getRandomIntInclusive(min, max) {
    const minCeiled = Math.ceil(min);
    const maxFloored = Math.floor(max);
    return Math.floor(Math.random() * (maxFloored - minCeiled + 1) + minCeiled);
}

function CreateCard(pokemon) {
    let card = CreateElement("div", ["card"]);

    let imgCont = CreateElement("div", ["card-img"]);
    let img = CreateElement("img");
    img.src = pokemon.sprites.front_default;
    imgCont.appendChild(img);
    card.appendChild(imgCont);

    let titleCont = CreateElement("div", ["card-title"]);
    let title = CreateElement("h2", [], pokemon.name);
    titleCont.appendChild(title);
    card.appendChild(titleCont);

    let cardContent = CreateElement("div", ["card-content"]);
    let dataContent = CreateElement("div");

    let heigthDiv = CreateElement("div", ["pokemon-data", "height"]);
    let heigthTitle = CreateElement("span", ["bold"], "Altura:");
    let heigth = CreateElement("span", ["pokemon-height"], pokemon.height);
    heigthDiv.appendChild(heigthTitle);
    heigthDiv.appendChild(heigth);
    dataContent.appendChild(heigthDiv);

    let weigthDiv = CreateElement("div", ["pokemon-data", "weight"]);
    let weigthTitle = CreateElement("span", ["bold"], "Peso:");
    let weigth = CreateElement("span", ["pokemon-weight"], pokemon.weight);
    weigthDiv.appendChild(weigthTitle);
    weigthDiv.appendChild(weigth);
    dataContent.appendChild(weigthDiv);

    cardContent.appendChild(dataContent);

    let abilitiesCont = CreateElement("div", ["pokemon-data", "abilities"]);
    let abilitiesTitle = CreateElement("span", ["bold"], "Habilidades:");
    abilitiesCont.appendChild(abilitiesTitle);
    let abilitiesUl = CreateElement("ul", ["abilities-list"]);
    pokemon.abilities.forEach(ability => {
        let li = CreateElement("li", [], ability.ability.name);
        abilitiesUl.appendChild(li);
    });
    abilitiesCont.appendChild(abilitiesUl);

    cardContent.appendChild(abilitiesCont);

    card.appendChild(cardContent);

    return card;
}
function CreateElement(elementType, classList = [], innerText = "") {
    let element = document.createElement(elementType);

    if (classList.length > 0) {
        classList.forEach(c => {
            element.classList.add(c);
        })
    }
    if (innerText !== "") {
        let textNode = document.createTextNode(innerText);
        element.appendChild(textNode)
    }
    return element;
}
