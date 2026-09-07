import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from './assets/vite.svg'
import heroImg from './assets/hero.png'
import './App.css'
// import EkaKomponentti from './EkaKomponentti'
// import Neliö from './Neliö'
// import LaskuriNapit from './LaskuriNapit'
// import TuoteTaulukko from './TuoteTaulukko'
// import ProductsTable from './TuoteTaulukko_AI'
import Lomake from './Lomake'
import TuoteTaulukkoSuodatus from './TuoteTaulukkoSuodatus'
import ColorPreview from './VäriEsikatselu'
import ColorInput from './VäriValinta'

function App() {
  const [count, setCount] = useState(0)
  const [color, setColor] = useState("#ff0000");

  return (
    <>
      <section id="center">
        <div className="hero">
          <img src={heroImg} className="base" width="170" height="179" alt="" />
          <img src={reactLogo} className="framework" alt="React logo" />
          <img src={viteLogo} className="vite" alt="Vite logo" />
        </div>
        <div>
          <h1>Get started</h1>

          <hr />
          <ColorInput color={color} onColorChange={setColor} />
          <ColorPreview color={color} />
          <hr />

          <Lomake />

          <TuoteTaulukkoSuodatus />
          {/*}
          <EkaKomponentti />
          <EkaKomponentti />
          <p>&nbsp;</p>
          <LaskuriNapit />
          <p>&nbsp;</p>
          <Neliö size={300} text="Moikka!" bgColor="lightblue" />
          <Neliö size={100} text="Toka!" bgColor="lightgreen" />
          <p>&nbsp;</p>
          <TuoteTaulukko />
          <hr />
          <ProductsTable />
          <p>
            Edit <code>src/App.tsx</code> and save to test <code>HMR</code>
          </p>
          */}
        </div>
        <button
          type="button"
          className="counter"
          onClick={() => setCount((count) => count + 1)}
        >
          Count is {count}
        </button>
      </section>

      <div className="ticks"></div>

      <section id="next-steps">
        <div id="docs">
          <svg className="icon" role="presentation" aria-hidden="true">
            <use href="/icons.svg#documentation-icon"></use>
          </svg>
          <h2>Documentation</h2>
          <p>Your questions, answered</p>
          <ul>
            <li>
              <a href="https://vite.dev/" target="_blank">
                <img className="logo" src={viteLogo} alt="" />
                Explore Vite
              </a>
            </li>
            <li>
              <a href="https://react.dev/" target="_blank">
                <img className="button-icon" src={reactLogo} alt="" />
                Learn more
              </a>
            </li>
          </ul>
        </div>
        <div id="social">
          <svg className="icon" role="presentation" aria-hidden="true">
            <use href="/icons.svg#social-icon"></use>
          </svg>
          <h2>Connect with us</h2>
          <p>Join the Vite community</p>
          <ul>
            <li>
              <a href="https://github.com/vitejs/vite" target="_blank">
                <svg
                  className="button-icon"
                  role="presentation"
                  aria-hidden="true"
                >
                  <use href="/icons.svg#github-icon"></use>
                </svg>
                GitHub
              </a>
            </li>
            <li>
              <a href="https://chat.vite.dev/" target="_blank">
                <svg
                  className="button-icon"
                  role="presentation"
                  aria-hidden="true"
                >
                  <use href="/icons.svg#discord-icon"></use>
                </svg>
                Discord
              </a>
            </li>
            <li>
              <a href="https://x.com/vite_js" target="_blank">
                <svg
                  className="button-icon"
                  role="presentation"
                  aria-hidden="true"
                >
                  <use href="/icons.svg#x-icon"></use>
                </svg>
                X.com
              </a>
            </li>
            <li>
              <a href="https://bsky.app/profile/vite.dev" target="_blank">
                <svg
                  className="button-icon"
                  role="presentation"
                  aria-hidden="true"
                >
                  <use href="/icons.svg#bluesky-icon"></use>
                </svg>
                Bluesky
              </a>
            </li>
          </ul>
        </div>
      </section>

      <div className="ticks"></div>
      <section id="spacer"></section>
    </>
  )
}

export default App
