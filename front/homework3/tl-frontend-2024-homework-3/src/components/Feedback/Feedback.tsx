import styles from "./Feedback.module.css"

type FeedbackProps = {
    rate: number
    name: string
    // iconSrc: string
    feedbackText: string
}

const Feedback = (props: FeedbackProps) => {
    const {
        rate,
        name,
        feedbackText
    } = props
    return (
        <div className={styles.wrapper}>
            <img className={styles.userIcon} src="../../public/img/userIcon.jpg" ></img>
            <div className={styles.nameAndText}>
                <div className={styles.name}>{name}</div>
                <div className={styles.feedbackText}>{feedbackText}</div>
            </div>
            <div className={styles.rate}>{rate}/5</div>
        </div>
    )
}

export {
    Feedback,
}

export type {
    FeedbackProps,
}