import { CurrencyCalculator } from './blocks/CurrencyCalculator/CurrencyCalculator'
import styles from "./App.module.css"

function App() {
  
  return (
    <div className={styles.wrapper} >
      <div className={styles.exchanger} >
        <CurrencyCalculator />
      </div>
    </div>
  )
}

export default App
