import { useState } from 'react';

function LaskuriNapit() {

  const [countA, setCountA] = useState(0);
  const [countB, setCountB] = useState(0);

  return (
    <div>
      <button onClick={() => setCountA(countA + 1)}>Nappi A</button>
      <button onClick={() => setCountB(countB + 1)}>Nappi B</button>
      <p>
        Laskuri A: {countA} | Laskuri B: {countB}
      </p>
    </div>
  );
}

export default LaskuriNapit;
