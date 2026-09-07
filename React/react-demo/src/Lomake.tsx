import { useState } from 'react'

function Lomake() {

    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [phone, setPhone] = useState('');

    const checkUserInput = () => {
        
        // all field are mandatory
        if (!name || !email || !phone) {
            alert('Täytä kaikki kentät!');
            return;
        }

        // validate email format using regex
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        if (!emailRegex.test(email)) {
            alert('Syötä kelvollinen sähköpostiosoite!');
            return;
        }

        // validate phone format using regex so that spaces are allowed, and there are at least 5 but at most 15 numbers
        const phoneRegex = /^[0-9\s]{5,15}$/;
        if (!phoneRegex.test(phone)) {
            alert('Syötä kelvollinen puhelinnumero!');
            return;
        }

        console.log('Checking user input:', { name, email, phone });
        alert('Käyttäjä lisätty onnistuneesti!');

        // reset form fields
        setName('');
        setEmail('');
        setPhone('');
    };

    return <div>
        <h2>Lisää käyttäjä</h2>
        <form>
            <label htmlFor="name">Nimi:</label>
            <input
                type="text"
                id="name"
                name="name"
                value={name}
                onChange={(e) => setName(e.target.value)}
            />
            <br />
            <label htmlFor="email">Sähköposti:</label>
            <input
                type="email"
                id="email"
                name="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
            />
            <br />
            <label htmlFor="phone">Puhelin:</label>
            <input
                type="tel"
                id="phone"
                name="phone"
                value={phone}
                onChange={(e) => setPhone(e.target.value)}
            />
            <br />
            <button type="button" onClick={() => checkUserInput()}>Lisää käyttäjä</button>
        </form>
    </div>;
}

export default Lomake;
