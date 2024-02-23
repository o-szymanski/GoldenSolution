import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import Menu from './pages/Menu.tsx'
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import './index.css'

const router = createBrowserRouter([
  { path: "/", element: <App /> },
  { path: "/Menu", element: <Menu /> }
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
)
