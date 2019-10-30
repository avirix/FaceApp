import React from 'react';
import ImageInfo from './ImageInfo';

interface ImageUploadState {
    file: string,
    imagePreviewUrl: string,
    faceData: any
}

class ImageUpload extends React.Component<{}, ImageUploadState>  {
    state = {
        file: '',
        imagePreviewUrl: '',
        faceData: {}
    };

    onImageSubmit(e: any) {
        e.preventDefault();
        fetch(
            new Request("localhost:5500", {
                method: "POST",
                body: JSON.stringify({ data: this.state.imagePreviewUrl })
            })
        ).then(
            (data) => this.setState({ faceData: data }),
            (e) => alert('Exception in request'));
        console.log('handle uploading-', this.state.file);
    }

    onImageChange(e: any) {
        e.preventDefault();

        let reader = new FileReader();
        let file = e.target.files[0];

        reader.onloadend = () => {
            this.setState({
                file: file as string,
                imagePreviewUrl: reader.result as string
            });
        }

        reader.readAsDataURL(file)
    }

    render() {
        let { imagePreviewUrl, faceData } = this.state;
        let $imagePreview = null;
        if (imagePreviewUrl) {
            $imagePreview = (<img src={imagePreviewUrl} alt="Ready to analyzing!" />);
        } else {
            $imagePreview = (<div className="previewText">Please select an Image for Preview</div>);
        }

        return (
            <div className="previewComponent">
                <form onSubmit={(e) => this.onImageSubmit(e)}>
                    <input className="fileInput"
                        type="file"
                        onChange={(e) => this.onImageChange(e)} />
                    <button className="submitButton"
                        type="submit"
                        onClick={(e) => this.onImageSubmit(e)}>Upload Image</button>
                </form>
                <div className="imgPreview">
                    {$imagePreview}
                </div>
                <ImageInfo data={faceData? faceData as string : imagePreviewUrl} />
            </div>
        )
    }
}

export default ImageUpload;