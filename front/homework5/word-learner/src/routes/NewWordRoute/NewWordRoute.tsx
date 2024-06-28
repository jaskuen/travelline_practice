import styles from "./NewWordRoute.module.scss"
import { useWordStore } from "../../functions/functions"
import { Button, IconButton, TextField, Typography } from "@mui/material"
import { useState } from "react"
import { WordType } from "../../types/types"
import { useNavigate } from "react-router-dom"
import { KeyboardArrowLeft } from "@mui/icons-material"

const NewWordRoute = () => {
    const navigator = useNavigate()
    const {words, addWord} = useWordStore()
    const [pair, setPair] = useState<WordType>({
        id: String(words.length + 1),
        russian: "",
        english: "",
    })
    const handleRuChange = (event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        setPair({
            ...pair,
            russian: event.target.value,
        })
    }
    const handleEnChange = (event: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        setPair({
            ...pair,
            english: event.target.value,
        })
    }
    const handleButtonClick = () => {
        addWord(pair)
        navigator("/dictionary")
    }
    return (
        <div className={styles.wrapper}>
            <div className={styles.header}>
                <Button variant="outlined" onClick={() => navigator("/dictionary")}>
                    <KeyboardArrowLeft />
                </Button>
                <Typography variant="h2">Добавить слово</Typography>
            </div>
            <div className={styles.changerWrapper}>
                <TextField 
                    label="Слово на русском языке" 
                    variant="outlined"
                    onChange={handleRuChange} 
                />
                <TextField 
                    label="Перевод на английский язык" 
                    variant="outlined"
                    onChange={handleEnChange} 
                />
                <Button 
                    disabled={pair.english == "" || pair.russian == ""}
                    variant="contained"
                    onClick={handleButtonClick}
                >
                    СОХРАНИТЬ
                </Button>
            </div>
        </div>
    )
}

export {
    NewWordRoute,
}