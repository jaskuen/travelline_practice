import { Button, MenuItem, Paper, Select, SelectChangeEvent, Typography } from "@mui/material"
import { useGenerateQuiz, useWordStore } from "../../functions/functions"
import styles from "./CheckRoute.module.scss"
import { useNavigate } from "react-router-dom"
import { KeyboardArrowLeft } from "@mui/icons-material"
import { useEffect, useMemo, useState } from "react"
import { QuizQuestion } from "../../types/types"

const CheckRoute = () => {
    const navigator = useNavigate()
    const { words } = useWordStore()
    const [quiz, setQuiz] = useState<Array<QuizQuestion>>([])
    const [questionNumber, setQuestionNumber] = useState<number>(0)
    const [currentQuestion, setCurrentQuestion] = useState<QuizQuestion>()
    const [answer, setAnswer] = useState<string>("")
    const [result, setResult] = useState<number>(0)

    const currentQuiz = useGenerateQuiz()

    useEffect(() => {
        setQuiz(currentQuiz)
        setCurrentQuestion(currentQuiz[0])
    }, [currentQuiz])

    useEffect(() => {
        if (quiz.length > 0) {
            setCurrentQuestion(quiz[questionNumber])
            console.log(questionNumber, quiz[questionNumber].word.russian)
        }
    }, [questionNumber, quiz])

    const handleChange = (event: SelectChangeEvent) => {
        setAnswer(event.target.value)
    }
    
    const handleCheckClick = () => {
        const isCorrect = answer === quiz[questionNumber].word.english ? 1 : 0
        setResult(prev => prev + isCorrect)
        setAnswer("")
        if (questionNumber + 1 === words.length) {
            navigator("/result", { 
                state: { 
                    result: result + isCorrect,
                    wordsCount: words.length, 
                }})
        }
        setQuestionNumber(questionNumber + 1)
    }

    

    return (
        <div className={styles.wrapper}>
            <div className={styles.header}>
                <Button variant="outlined" onClick={() => navigator("/")}>
                    <KeyboardArrowLeft />
                </Button>
                <Typography variant="h3" >Проверка знаний</Typography>
            </div>
            <Typography variant="h4">Слово: {questionNumber + 1} из {words.length}</Typography>
            <Paper className={styles.testWrapper}>
                <div className={styles.rowWrapper}>
                    <Typography variant="subtitle1" className={styles.text}>Слово на русском языке</Typography>
                    <Typography variant="subtitle1" className={styles.wordWrapper}>{currentQuestion?.word? currentQuestion.word.russian : ""}</Typography> 
                </div>
                <div className={styles.rowWrapper}>
                    <Typography variant="subtitle1" className={styles.text}>Перевод на английский язык</Typography>
                    <Select
                        value={answer}
                        label="Ответ"
                        onChange={handleChange}
                    >
                        {currentQuestion?.possibleTranslates? currentQuestion.possibleTranslates.map((translate, index) => {
                            return <MenuItem key={index} value={translate}>{translate}</MenuItem> 
                        }) : null}
                    </Select>
                </div>
            </Paper>
            <Button disabled={answer===""} variant="contained" onClick={handleCheckClick}>ПРОВЕРИТЬ</Button>
        </div>
    )
}

export {
    CheckRoute,
}