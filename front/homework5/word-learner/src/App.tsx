import React, { useState } from 'react'
import './App.css'
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import { MainRoute } from './routes/MainRoute/MainRoute';
import { DictionaryRoute } from './routes/DictionaryRoute/DictionaryRoute';

const router = createBrowserRouter([
  {
    path: "/",
    element: <MainRoute />,
  },
  {
    path: "/dictionary",
    element: <DictionaryRoute />
  }
]);

const App = () => {
  return (
    <React.StrictMode>
      <RouterProvider router={router} />
    </React.StrictMode>
)
}

export default App
