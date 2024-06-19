import { create } from 'zustand'
import { WordType } from '../types/types'
import { persist } from 'zustand/middleware'

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

export {
    useWordStore,
}

export type {
    StateType,
}