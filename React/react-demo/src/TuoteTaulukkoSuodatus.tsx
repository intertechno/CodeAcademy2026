import { useEffect, useState } from "react";

type Tuote = {
    id: number;
    title: string;
    category: string;
    price: number;
};

function TuoteTaulukkoSuodatus() {

    console.log("TuoteTaulukkoSuodatus alkaa");
    const [tuotteet, setTuotteet] = useState<Tuote[]>([]);
    const [ladataan, setLadataan] = useState(true);
    const [tuotteetSuodatettu, setTuotteetSuodatettu] = useState<Tuote[]>([]);

    useEffect(() => {
        console.log("TuoteTaulukkoSuodatus useEffect");

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
            <th>Kategoria<br />
              <input type="text" placeholder="Suodata" onChange={(e) => {
                const suodatus = e.target.value.toLowerCase();
                setTuotteetSuodatettu(tuotteet.filter(
                    tuote => tuote.category.toLowerCase().includes(suodatus)));
              }} />
            </th>
            <th>Hinta</th>
        </tr>
    </thead>
    <tbody>
        {(tuotteetSuodatettu.length > 0 ? tuotteetSuodatettu : tuotteet).map((tuote: Tuote) => (
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

export default TuoteTaulukkoSuodatus;
