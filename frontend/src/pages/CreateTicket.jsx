import { useState } from "react";
import InputField from "../components/InputField";
import axios from "axios";
import "../App.css";

function CreateTicket() {
  const [titulo, setTitulo] = useState("");
  const [descripcion, setDescripcion] = useState("");
  const [isSubmitting, setIsSubmitting] = useState(false);

  const [errors, setErrors] = useState({});
  const [message, setMessage] = useState({ text: "", type: "" });

  const validate = () => {
    let newErrors = {};

    if (!titulo.trim()) {
      newErrors.titulo = "El título es obligatorio";
    } else if (titulo.length < 5) {
      newErrors.titulo = "El título debe tener al menos 5 caracteres";
    } else if (titulo.length > 100) {
      newErrors.titulo = "El título no puede exceder 100 caracteres";
    }

    if (!descripcion.trim()) {
      newErrors.descripcion = "La descripción es obligatoria";
    } else if (descripcion.length < 10) {
      newErrors.descripcion = "La descripción debe tener al menos 10 caracteres";
    } else if (descripcion.length > 500) {
      newErrors.descripcion = "La descripción no puede exceder 500 caracteres";
    }

    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    setMessage({ text: "", type: "" });

    if (!validate()) return;

    setIsSubmitting(true);
    try {
      await axios.post("http://localhost:5139/api/ticket", {
        titulo,
        descripcion,
      });

      setMessage({ text: "¡Ticket registrado con éxito!", type: "success" });
      setTitulo("");
      setDescripcion("");
      setErrors({});
    } catch (error) {
      console.error(error);
      setMessage({ text: "Error al registrar el ticket. Inténtalo de nuevo.", type: "error" });
    } finally {
      setIsSubmitting(false);
    }
  };

  return (
    <div className="container">
      <div className="card">
        <header className="header">
          <div className="icon-badge">
            <svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="2" strokeLinecap="round" strokeLinejoin="round">
              <path d="M2 9V5.2a2 2 0 0 1 2-2h16a2 2 0 0 1 2 2V9"></path>
              <path d="M2 15v3.8a2 2 0 0 0 2 2h16a2 2 0 0 0 2-2V15"></path>
              <path d="M2 12h2"></path>
              <path d="M20 12h2"></path>
              <path d="m15 12-3-3-3 3"></path>
              <path d="m12 9v6"></path>
            </svg>
          </div>
          <h2>Nuevo Ticket</h2>
          <p>Completa la información para reportar un incidente</p>
        </header>

        <form onSubmit={handleSubmit}>
          <InputField
            label="Asunto del Ticket"
            value={titulo}
            onChange={(e) => setTitulo(e.target.value)}
            error={errors.titulo}
            placeholder="Ej: Error al procesar pago..."
          />

          <InputField
            label="Descripción Detallada"
            type="textarea"
            value={descripcion}
            onChange={(e) => setDescripcion(e.target.value)}
            error={errors.descripcion}
            placeholder="Describe el problema con el mayor detalle posible..."
          />

          <div className="form-footer">
            <button 
              type="submit" 
              className={`submit-btn ${isSubmitting ? 'loading' : ''}`}
              disabled={isSubmitting}
            >
              {isSubmitting ? (
                <>
                  <span className="spinner"></span>
                  Procesando...
                </>
              ) : (
                "Registrar Ticket"
              )}
            </button>
          </div>
        </form>

        {message.text && (
          <div className={`message ${message.type}`}>
            {message.text}
          </div>
        )}
      </div>
    </div>
  );
}

export default CreateTicket;