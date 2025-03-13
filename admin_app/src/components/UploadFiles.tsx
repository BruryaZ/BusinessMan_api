import React, { useState } from 'react';
import * as pdfjsLib from 'pdfjs-dist';

// הגדרת מקור העובד לגרסה הנכונה
pdfjsLib.GlobalWorkerOptions.workerSrc = `https://cdnjs.cloudflare.com/ajax/libs/pdf.js/4.10.38/pdf.worker.min.js`;

const FileUpload: React.FC = () => {
    const [pdfText, setPdfText] = useState<string | null>(null);

    const handleFileChange = async (event: React.ChangeEvent<HTMLInputElement>) => {
        const file = event.target.files?.[0]; // בחר את הקובץ הראשון
        if (file && file.type === 'application/pdf') {
            const fileReader = new FileReader();
            fileReader.onload = async () => {
                const typedarray = new Uint8Array(fileReader.result as ArrayBuffer);
                const pdf = await pdfjsLib.getDocument(typedarray).promise;

                let text = '';
                for (let i = 1; i <= pdf.numPages; i++) {
                    const page = await pdf.getPage(i);
                    const content = await page.getTextContent();
                    const pageText = content.items.map((item: any) => item.str).join(' ');
                    text += pageText + '\n';
                }
                setPdfText(text);
            };
            fileReader.readAsArrayBuffer(file); // קרא את הקובץ כ-array buffer
        } else {
            alert("אנא בחר קובץ PDF.");
        }
    };

    return (
        <div>
            <input type="file" onChange={handleFileChange} accept="application/pdf" />
            {pdfText && (
                <div>
                    <h3>תוכן הקובץ PDF:</h3>
                    <pre>{pdfText}</pre>
                </div>
            )}
        </div>
    );
};

export default FileUpload;
