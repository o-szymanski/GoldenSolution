import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import Menu from './pages/Menu.tsx'
import { RouterProvider, createBrowserRouter } from "react-router-dom";
import './index.css'
import './components/LanguageSelector/i18n.tsx'

const router = createBrowserRouter([
  { path: "/", element: <App /> },
  { path: "/Menu", element: <Menu /> }
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <React.Suspense fallback="loading...">
      <RouterProvider router={router} />
    </React.Suspense>
  </React.StrictMode>,
)
