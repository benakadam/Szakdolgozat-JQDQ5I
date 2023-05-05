from img2vec_pytorch import Img2Vec
from PIL import Image
from sklearn.metrics.pairwise import cosine_similarity
import numpy as np
import pickle
import argparse

ap = argparse.ArgumentParser()
ap.add_argument("-v", "--vectors", required=True, type=str,
    help="path to the input vectors.pickle")
ap.add_argument("-q", "--query", required=True, type=str,
    help="path to the input query image")
args = vars(ap.parse_args())

vectors = args["vectors"]
queryImage = args["query"]

img2vec = Img2Vec()

with open(vectors, 'rb') as f:
    data = pickle.load(f)

filenames = data['filenames']
vecs = data['vecs']

# Adott kep betoltese
image = Image.open(queryImage).convert('RGB')
vecs.insert(0, img2vec.get_vec(image))

# Cosine similarity - elso elemet hasonlitjuk ossze az osszes tobbivel
sims = cosine_similarity(vecs[0:1], vecs[1:])



# Hasonlosagi ertek feletti kepek meghatarozasa
# threshold = 0.9
# most_similars = np.where(sims[0] >= threshold)[0]
# 
# sorted_similars = sorted(zip(most_similars, sims[0][most_similars]), key=lambda x: x[1], reverse=True)
# 
# for pic, sim in sorted_similars:
#     print(filenames[pic], sim)
# Hasonlosagi ertek feletti kepek meghatarozasa


# Leghasonlobb
# most_similar_image_index = np.argmax(sims)

# most_similar_image_name = filenames[most_similar_image_index]
# print(most_similar_image_name)
# Leghasonlobb



# top 10 leghasonlobb
# most_similars = np.argsort(sims[0])[::-1][:10]
# for pic in most_similars:
#     print(filenames[pic], sims[0][pic])
# top 10 leghasonlobb




most_similar = np.argsort(sims[0])[::-1][:1]

if sims[0][most_similar[0]] > 0.9:
    most_similar_name = filenames[most_similar[0]]
    print(most_similar_name)
else:
    print("Nincs talalat")
