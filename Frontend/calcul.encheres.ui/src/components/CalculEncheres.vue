<template>
  <h2>Calculer le Prix Total des Enchères</h2>
  <div class="container">
      <div class="div-gauche">
        <h3>Coût fixes et variables</h3>
        <ul>
              <li>Frais de base de l’acheteur: 10% du prix du véhicule
                  <ul>
                      <li>Ordinaire: minimum 10$ et maximum 50$</li>
                      <li>De luxe: minimum 25$ et maximum 200$</li>
                  </ul>
              </li>
              <li>Frais spéciaux du vendeur:
                  <ul>
                      <li>Ordinaire: 2% du prix du véhicule</li>
                      <li>De luxe: 4% du prix du véhicule</li>
                  </ul>
              </li>
              <li>Les frais supplémentaires d'association en fonction du prix du véhicule:
                  <ul>
                      <li>5$ pour un montant compris entre 1$ et 500$</li>
                      <li>10$ pour un montant supérieur à 500$ et inférieur ou égal à 1000$</li>
                      <li>15$ pour un montant supérieur à 1000$ et inférieur ou égal à 3000$</li>
                      <li>o	20$ pour un montant supérieur à 3000$</li>
                  </ul>
              </li>
              <li>Des frais d'entreposage fixes de 100$</li>
        </ul>
      </div>
      <div class="div-droite">
        <div class="calcul-encheres">
          <form @submit.prevent="calculerPrixTotal">
            <div>
              <label for="basePrice">Prix de Base :</label>
              <input type="number" id="basePrice" v-model.number="form.prixDeBase" required placeholder="Entrez le prix de base"/>
            </div>
            <div>
              <label for="typeVoiture">Type de Voiture :</label>
              <select id="typeVoiture" v-model="form.typeVoiture" required>
                <option value="" disabled>Choisir un type</option>
                <option value="Ordinaire">Ordinaire</option>
                <option value="Luxe">Luxe</option>
              </select>
            </div>
            <button type="submit">Calculer</button>
          </form>

          <div v-if="PrixTotal !== null">
            <h3>Le prix Total est : {{ prixTotalFormate  }}</h3>
          </div>
          <div v-if="erreur">
            <p class="erreur">{{ erreur }}</p>
          </div>
      </div>
        
    </div>
  </div>
</template>

<script>
import '../assets/CalculEncheres.css';
import axios from 'axios';

export default {
  name: 'CalculEncheres',
  data() {
    return {
      form: {
        prixDeBase: null,
        typeVoiture: ''
      },
      PrixTotal: null,
      erreur: null
    };
  },
  computed: {
    prixTotalFormate() {
      if (this.PrixTotal !== null) {
        return this.PrixTotal.toLocaleString('fr-FR', {
          style: 'currency',
          currency: 'CAD',
          minimumFractionDigits: 2
        });
      }
      return null;
    }
  },
  methods: {
    async calculerPrixTotal() {
      this.erreur = null;
      this.PrixTotal = null;

      const typeVoitureMap = {
        Ordinaire: 0,
        Luxe: 1
      };

      try {
        const response = await axios.post('https://localhost:7075/api/CalculEncheres/CalculPrixTotal', {
          TypeVoiture: typeVoitureMap[this.form.typeVoiture],
          PrixDeBase: this.form.prixDeBase
        });
        this.PrixTotal = response.data;
      } catch (erreur) {
        this.erreur = 'Erreur lors du calcul du prix total : ' + (erreur.response?.data || erreur.message);
      }
    }
  }
};
</script>