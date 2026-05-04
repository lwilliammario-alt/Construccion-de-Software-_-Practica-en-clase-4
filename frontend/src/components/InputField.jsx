const InputField = ({ label, value, onChange }) => {
  return (
    <div>
      <label>{label}</label><br />
      <input value={value} onChange={onChange} />
    </div>
  );
};

export default InputField;