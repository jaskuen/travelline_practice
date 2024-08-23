import { create } from 'zustand'
import { QuizQuestion, WordType } from '../types/types'
import { persist } from 'zustand/middleware'
import { useEffect, useState } from 'react'

type StateType = {
    words: Array<WordType>,
    addWord: (newWord: WordType) => void,
    editWord: (changedWord: WordType) => void,
    deleteWord: (wordId: string) => void,
}

const useWordStore = create(persist<StateType>(
    (set) => ({
        words: [],
        addWord: (newWord: WordType) => set((state: StateType) => ({
            words: [...state.words, newWord]
        })),
        editWord: (changedWord: WordType) => set((state: StateType) => ({
            words: [...state.words.map(word => {
                if (word.id == changedWord.id) {
                    return changedWord
                }
                return word
            })]
        })),
        deleteWord: (wordId: string) => set((state: StateType) => ({
            words: [...state.words.filter(word => word.id !== wordId)]
        }))}),
        {
            name: 'word-storage', 
            getStorage: () => localStorage, 
        }     
))

const shuffleArray = <T>(array: T[], size: number, mandatoryItem?: T): T[] => {
    let shuffled = [...array].sort(() => 0.5 - Math.random())

    let result = new Set<T>()

    if (mandatoryItem) {
        result.add(mandatoryItem)
    }

    while (result.size < size) {
        const j = Math.floor(Math.random() * shuffled.length)
        result.add(shuffled[j])
    }

    let finalArray = Array.from(result);
    for (let i = finalArray.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [finalArray[i], finalArray[j]] = [finalArray[j], finalArray[i]]
    }

    return finalArray
}



const useGenerateQuiz = (): Array<QuizQuestion> => {
    const { words } = useWordStore()

    const answersArray = words.map(word => {return word.english})
    const answersCount = words.length > 4 ? 4 : words.length

    const initialQuiz = shuffleArray<WordType>(words, words.length).map(word => {
        return {
            word: word,
            possibleTranslates: shuffleArray<string>(answersArray, answersCount, word.english),
        }
    })
    
    const [quiz, setQuiz] = useState<Array<QuizQuestion>>(initialQuiz)
    
    useEffect(() => {
        setQuiz([...shuffleArray<WordType>(words, words.length).map(word => {
            return {
                word: word,
                possibleTranslates: shuffleArray<string>(answersArray, answersCount, word.english),
            }
        })])
    }, [words])
    
    return quiz
}

export {
    useWordStore,
    useGenerateQuiz,
}

export type {
    StateType,
}