type WordType = {
    id: string,
    russian: string,
    english: string,
}

type QuizQuestion = {
    word: WordType,
    possibleTranslates: Array<string>,
}

export type {
    WordType,
    QuizQuestion,
}