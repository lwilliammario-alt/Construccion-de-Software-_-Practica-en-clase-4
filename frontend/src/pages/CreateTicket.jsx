import { useState } from "react";
import { createTicket } from "../services/ticketService";
import FormMessage from "../components/FormMessage";
import InputField from "../components/InputField";

const CreateTicket = () => {
  const [titulo, setTitulo] = useState("");
  const [descripcion, setDescripcion] = useState("");
  const [mensaje, setMensaje] = useState("");
  const [tipo, setTipo] = useState("");

  const handleSubmit = async (e) => {
    e.preventDefault();

    if (titulo.trim() === "" || descripcion.trim() === "") {
      setMensaje("Completa todos los campos");
      setTipo("error");
      return;
    }

    try {
      await createTicket({ titulo, descripcion });
      setMensaje("Ticket registrado correctamente");
      setTipo("success");
      setTitulo("");
      setDescripcion("");
    } catch {
      setMensaje("Error al registrar");
      setTipo("error");
    }
  };

  return (
    <div>
      <h2>Registrar Ticket</h2>

      <FormMessage message={mensaje} type={tipo} />

      <form onSubmit={handleSubmit}>
        <InputField
          label="Título"
          value={titulo}
          onChange={(e) => setTitulo(e.target.value)}
        />

        <div>
          <label>Descripción</label><br />
          <textarea
            value={descripcion}
            onChange={(e) => setDescripcion(e.target.value)}
          />
        </div>

        <button type="submit">Registrar</button>
      </form>
    </div>
  );
};

export default CreateTicket;