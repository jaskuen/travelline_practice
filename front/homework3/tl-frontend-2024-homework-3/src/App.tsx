import { useEffect, useState } from 'react'
import { generateUID } from '../public/functions'
import { RateTable, RateTableProps } from './blocks/RateTable/RateTable'
import styles from './App.module.css'
import { TextBlock } from './components/TextBlockComponent/TextBlock'
import { FeedbackForm } from './blocks/FeedbackForm/FeedbackForm'
import { Feedback, FeedbackProps } from './components/Feedback/Feedback'

function App() {
    const [count, setCount] = useState<number>(localStorage.length)
    const [rate, setRate] = useState<number>(1)
    const [feedbacks, setFeedbacks] = useState<Array<FeedbackProps>>([])
    // const rangeFieldProps: RangeFieldProps = {
    //     id: generateUID(),
    //     handleChange: () => console.log
    // }
    useEffect(() => {
        const newFeedbacks = Object.keys(localStorage).reduce((acc: Array<FeedbackProps>, key) => {
            const oldFeedback = localStorage.getItem(key)
            if (oldFeedback !== null) {
                acc.push(JSON.parse(oldFeedback))
            }
            return acc
        }, [])
    
        setFeedbacks(newFeedbacks)
    }, [])
    const rateTableProps: RateTableProps = {
        getRate: (rate: number) => setRate(Number(rate.toFixed(1)))
    }

    const makeFeedback = (name: string, feedback: string) => {
        const newFeedback: FeedbackProps = {
            name: name,
            feedbackText: feedback,
            rate: rate
        }
        setFeedbacks([...feedbacks, newFeedback])
        localStorage.setItem(String(count), JSON.stringify(newFeedback))
        setCount(count + 1);
        console.log(newFeedback.name, newFeedback.rate)
    }
    useEffect(() => {
        console.log(rate)
    }, [rate])
    return (
        <div className={styles.wrapper}>
            <div id={generateUID()} className={styles.form}>
                <TextBlock id={generateUID()} text='Помогите нам сделать процесс бронирования лучше' />
                <RateTable {...rateTableProps}/>
                <TextBlock id={generateUID()} text={'Текущая оценка: ' + rate} />
                <FeedbackForm getFeedback={makeFeedback}/>
            </div>
            <div id={generateUID()} className={styles.feedbacks}>
                {feedbacks.map((f) => {
                    const props: FeedbackProps = {
                        rate: f.rate,
                        name: f.name,
                        feedbackText: f.feedbackText
                    }
                    return (
                        <Feedback {...props} />
                    )
                })}
            </div>
        </div>
    )
}

export default App
