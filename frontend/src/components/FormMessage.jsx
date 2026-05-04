const FormMessage = ({ message, type }) => {
  if (!message) return null;

  return (
    <p style={{ color: type === "error" ? "red" : "green" }}>
      {message}
    </p>
  );
};

export default FormMessage;