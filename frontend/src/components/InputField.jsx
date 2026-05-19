import "./InputField.css";

function InputField({
  label,
  type = "text",
  value,
  onChange,
  error,
  placeholder
}) {
  return (
    <div className={`input-group ${error ? "has-error" : ""}`}>
      <label className="input-label">{label}</label>
      <div className="input-wrapper">
        {type === "textarea" ? (
          <textarea
            value={value}
            onChange={onChange}
            className="input-field textarea"
            placeholder={placeholder}
          />
        ) : (
          <input
            type={type}
            value={value}
            onChange={onChange}
            className="input-field"
            placeholder={placeholder}
          />
        )}
        <div className="input-focus-bg"></div>
      </div>
      {error && <p className="error-message">{error}</p>}
    </div>
  );
}

export default InputField;