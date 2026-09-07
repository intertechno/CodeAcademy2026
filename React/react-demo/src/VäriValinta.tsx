import type { ChangeEvent } from "react";

interface ColorInputProps {
    color: string;
    onColorChange: (newColor: string) => void;
};

function ColorInput({ color, onColorChange }: ColorInputProps) {

    const handleColorPickerChange = (event: ChangeEvent<HTMLInputElement>) => {
        onColorChange(event.target.value);
    };

    const handleTextChange = (event: ChangeEvent<HTMLInputElement>) => {
        const value = event.target.value;
        // Always ensure it starts with "#"
        const withHash = value.startsWith("#") ? value : `#${value}`;
        onColorChange(withHash);
    };

    return (
        <div style={{ marginBottom: "1rem" }}>
            <h2>Pick a color</h2>

            <div style={{ display: "flex", gap: "0.75rem", alignItems: "center" }}>
                <label>
                    Color picker:{" "}
                    <input
                        type="color"
                        value={color}
                        onChange={handleColorPickerChange}
                    />
                </label>

                <label>
                    Hex value:{" "}
                    <input
                        type="text"
                        value={color}
                        onChange={handleTextChange}
                        placeholder="#ff0000"
                    />
                </label>
            </div>
        </div>
    );
};

export default ColorInput;