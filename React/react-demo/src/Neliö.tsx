type NeliöProps = {
  size: number;
  text: string;
  bgColor: string;
};

function Neliö({size, text, bgColor}: NeliöProps) {
  return <div style={{width: size, height: size,
    fontSize: size / 5, display: 'flex',
    alignItems: 'center', justifyContent: 'center',
    backgroundColor: bgColor}}>{text}</div>;
}

export default Neliö;
