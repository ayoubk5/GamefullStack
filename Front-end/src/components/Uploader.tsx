import {  ChangeEvent } from 'react';
import { MdCloudUpload } from 'react-icons/md';
import { Box, Input } from '@chakra-ui/react';
interface FileUploaderProps {
    image:string | null,
    handleFile: (image:string) => void;
  }
const Uploader=({ image,handleFile }:FileUploaderProps)=> {

  const handleFileChange = (e: ChangeEvent<HTMLInputElement>) => {
    let files = e.target.files;
    if (files && files.length > 0) {
      let fileReader = new FileReader();
      fileReader.readAsDataURL(files[0]);  
      fileReader.onload = async (event) => {
      handleFile(event.target?.result as string);
      };
    }
  };



  return (
    <main>
      <Box  marginTop={5} 
      marginX='auto'
            id="uploaderForm" onClick={() => document.querySelector<HTMLInputElement>('.input-field')?.click()}>
        <Input
          type="file"
          accept="image/*"
          className="input-field"
          hidden
          onChange={handleFileChange}
        />

        {image ? (
          <img src={image}  alt={"image"} style={{ width: '200px', height: '200px' }} />
        ) : (
          <>
            <MdCloudUpload color="#1475cf" size={60} />
            <p>Browse Image to upload</p>
          </>
        )}
      </Box>
    </main>
  );
}

export default Uploader;
