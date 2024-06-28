import React, { useState } from 'react'
import './App.css'
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import { MainRoute } from './routes/MainRoute/MainRoute';
import { DictionaryRoute } from './routes/DictionaryRoute/DictionaryRoute';
import { NewWordRoute } from './routes/NewWordRoute/NewWordRoute';
import { EditWordRoute } from './routes/EditWordRoute/EditWordRoute';
import { CheckRoute } from './routes/CheckRoute/CheckRoute';
import { ResultRoute } from './routes/ResultRoute/ResultRoute';

const router = createBrowserRouter([
  {
    path: "/",
    element: <MainRoute />,
  },
  {
    path: "/dictionary",
    element: <DictionaryRoute />
  },
  {
    path: "/new-word",
    element: <NewWordRoute />
  },
  {
    path: "/edit-word",
    element: <EditWordRoute />
  },
  {
    path: "/check",
    element: <CheckRoute />
  },
  {
    path: "/result",
    element: <ResultRoute />
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
