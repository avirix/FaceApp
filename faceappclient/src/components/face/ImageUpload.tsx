import React from 'react';
import ImageInfo from './ImageInfo';
import axios from 'axios';
import FaceDetail from './analyzer/FaceDetail';
import { FaceModel } from './analyzer/FaceModel';

interface ImageUploadState {
    file: string,
    imagePreviewUrl: string,
    faceData: FaceModel[]
}

class ImageUpload extends React.Component<{}, ImageUploadState>  {
    state = {
        file: '',
        imagePreviewUrl: '',
        faceData: [] as FaceModel[]
    };

    onImageSubmit(e: any) {
        e.preventDefault();
        var config = {
            headers: {'Access-Control-Allow-Origin': '*'}
        };
        axios.post('http://192.168.0.103:5500/api/face', { image: this.state.imagePreviewUrl }, config)
            .then((response) => {
                let data = response.data;
                console.log(data);
                this.setState({ faceData: data.Data });
            });
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

        let imageInfoData: string = faceData ? "" + faceData : imagePreviewUrl;
        console.log(imageInfoData);
        return (
            <div className="previewComponent" >
                <form onSubmit={(e) => this.onImageSubmit(e)} style={{ width: '50%', margin: "15px auto", position: "relative" }}>
                    <input className="fileInput"
                        type="file"
                        onChange={(e) => this.onImageChange(e)} />
                    <button className="submitButton float-right btn btn-success"
                        type="submit"
                        onClick={(e) => this.onImageSubmit(e)}>Upload Image</button>
                    <div className="imgPreview">
                        <FaceDetail list={this.state.faceData} imagePreview={imagePreviewUrl}></FaceDetail>
                    </div>
                </form>
                <ImageInfo data={this.state.faceData} />
            </div>
        )
    }
}

export default ImageUpload;