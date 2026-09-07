import { useEffect, useState } from "react";

type Tuote = {
    id: number;
    title: string;
    category: string;
    price: number;
};

function TuoteTaulukko() {

    console.log("TuoteTaulukko alkaa");
    const [tuotteet, setTuotteet] = useState<Tuote[]>([]);
    const [ladataan, setLadataan] = useState(true);

    useEffect(() => {
        console.log("TuoteTaulukko useEffect");

        if (!ladataan) {
            console.log("Tuotteet ladattu, ei tarvitse hakea uudestaan");
            return;
        }
        const url = "https://dummyjson.com/products";
        fetch(url)
            .then(response => response.json())
            .then(data => {
                console.log("Tuotteet haettu:", data);
                setTuotteet(data.products);
            })
            .catch(error => {
                console.error("Virhe tuotteiden haussa:", error);
            })
            .finally(() => {
                setLadataan(false);
            });
    }, [ladataan]);

    console.log("TuoteTaulukko renderöityy");
    return <table>
    <thead>
        <tr>
            <th>ID</th>
            <th>Nimi</th>
            <th>Kategoria</th>
            <th>Hinta</th>
        </tr>
    </thead>
    <tbody>
        {tuotteet.map((tuote: Tuote) => (
            <tr key={tuote.id}>
                <td>{tuote.id}</td>
                <td>{tuote.title}</td>
                <td>{tuote.category}</td>
                <td>{tuote.price}</td>
            </tr>
        ))}
    </tbody>
    </table>;
}

export default TuoteTaulukko;
