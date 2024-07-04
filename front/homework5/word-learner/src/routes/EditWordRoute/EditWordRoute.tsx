import { KeyboardArrowLeft } from "@mui/icons-material"
import { Button, Typography, TextField } from "@mui/material"
import { useEffect, useState } from "react"
import { useLocation, useNavigate } from "react-router-dom"
import { useWordStore } from "../../functions/functions"
import { WordType } from "../../types/types"
import styles from "./EditWordRoute.module.scss"

const EditWordRoute = () => {
    const navigator = useNavigate()
    const location = useLocation()
    const {words, editWord} = useWordStore()
    const [pair, setPair] = useState<WordType>({
        id: location.state.id,
        russian: "",
        english: "",
    })

    useEffect(() => {
        const currentWord = words.find(word => word.id === pair.id)
        if (currentWord) {
            setPair({
                id: pair.id,
                russian: currentWord.russian,
                english: currentWord.english,
            })
        }
    }, [])
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
        editWord(pair)
        navigator("/dictionary")
    }
    return (
        <div className={styles.wrapper}>
            <div className={styles.header}>
                <Button variant="outlined" onClick={() => navigator("/dictionary")}>
                    <KeyboardArrowLeft />
                </Button>
                <Typography variant="h2">Изменить слово</Typography>
            </div>
            <div className={styles.changerWrapper}>
                <TextField 
                    value={pair.russian}
                    label="Слово на русском языке" 
                    variant="outlined"
                    onChange={handleRuChange} 
                />
                <TextField 
                    value={pair.english}
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
    EditWordRoute,
}