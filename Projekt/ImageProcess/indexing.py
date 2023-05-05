import os
import pickle
from img2vec_pytorch import Img2Vec
from PIL import Image
import argparse

ap = argparse.ArgumentParser()
ap.add_argument("-i", "--input", required=True, type=str,
    help="path to the input directory")
ap.add_argument("-o", "--output", required=True, type=str,
    help="path to the output directory")
args = vars(ap.parse_args())

inputPath = args["input"]
outputPath = args["output"]

img2vec = Img2Vec()

vecs = []
filenames = []

for filename in os.listdir(inputPath):
    if filename.endswith('.jpg') or filename.endswith('.jpeg') or filename.endswith('.png'):
        filenames.append(filename)
        image = Image.open(os.path.join(inputPath, filename)).convert('RGB')
        vecs.append(img2vec.get_vec(image))

with open(outputPath, 'wb') as f:
    pickle.dump({'filenames': filenames, 'vecs': vecs}, f)
