import { useEffect, useState } from "react"
import { generateUID } from "../../../public/functions"
import { InputField } from "../../components/InputFieldComponent/InputField"
import styles from "./FeedbackForm.module.css"
import { Button } from "../../components/ButtonComponent/Button"

type FeedbackFormProps = {
    getFeedback: (name: string, feedback: string) => void
}

const FeedbackForm = (props: FeedbackFormProps) => {
    const {
        getFeedback,
    } = props
    const [name, setName] = useState<string>("")
    const [feedback, setFeedback] = useState<string>("")
    const [disabled, setDisabled] = useState<boolean>(true)
    useEffect(() => {
        setDisabled(name == "" && feedback == "")
    }, [name, feedback])

    const sendFeedback = () => {
        getFeedback(name, feedback)
    }
    
    return (
        <div className={styles.wrapper}>
            <InputField id={generateUID()} type='name' name='*Имя' defaultValue='Как вас зовут?' onChange={setName} />
            <InputField id={generateUID()} type='feedback' defaultValue='Напишите, что понравилось, что было непонятно' onChange={setFeedback} />
            <Button id={generateUID()} disabled={disabled} name='Отправить' onClick={sendFeedback} />
        </div>
    )
}

export {
    FeedbackForm,
}