// Importa StrictMode de React para detectar problemas potenciales durante el desarrollo
import { StrictMode } from 'react'

// Importa createRoot de React DOM para montar la aplicación en el DOM de forma moderna (React 18+)
import { createRoot } from 'react-dom/client'

// Importa los estilos globales de la aplicación
import './index.css'

// Importa el componente raíz de la aplicación
import App from './App.jsx'

// Selecciona el elemento HTML con id "root" y crea la raíz de React sobre él
// Luego renderiza el componente App envuelto en StrictMode para activar advertencias adicionales
createRoot(document.getElementById('root')).render(
  // StrictMode ejecuta algunos hooks dos veces en desarrollo para detectar efectos secundarios inesperados
  <StrictMode>
    {/* Componente principal de la aplicación */}
    <App />
  </StrictMode>,
)
