const API_URL = "http://localhost:5153/api/ticket";

export const createTicket = async (ticket) => {
  const response = await fetch(API_URL, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(ticket),
  });

  if (!response.ok) {
    throw new Error("Error al registrar");
  }

  return await response.json();
};