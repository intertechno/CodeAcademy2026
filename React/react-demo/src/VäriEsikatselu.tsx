interface ColorPreviewProps {
  color: string;
};

// Helper: convert hex color (#rrggbb) to "r, g, b" string
function hexToRgb(hex: string): string | null {
  const cleaned = hex.replace("#", "").trim();

  if (cleaned.length !== 6) return null;

  const r = parseInt(cleaned.slice(0, 2), 16);
  const g = parseInt(cleaned.slice(2, 4), 16);
  const b = parseInt(cleaned.slice(4, 6), 16);

  if ([r, g, b].some((v) => Number.isNaN(v))) return null;

  return `${r}, ${g}, ${b}`;
}

function ColorPreview({ color }: ColorPreviewProps) {
  const rgb = hexToRgb(color);

  return (
    <div>
      <h2>Preview</h2>

      <div
        style={{
          width: "200px",
          height: "100px",
          borderRadius: "8px",
          border: "1px solid #ccc",
          backgroundColor: color,
          marginBottom: "0.75rem",
        }}
      />

      <div>
        <div>
          <strong>Hex:</strong> {color}
        </div>
        <div>
          <strong>RGB:</strong>{" "}
          {rgb ? `rgb(${rgb})` : <span style={{ color: "red" }}>Invalid color</span>}
        </div>
      </div>
    </div>
  );
};

export default ColorPreview;
