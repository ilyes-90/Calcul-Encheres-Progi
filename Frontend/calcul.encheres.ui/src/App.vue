<template>
  <div id="app">
    <CalculEncheres />
  </div>
</template>

<script>
import CalculEncheres from './components/CalculEncheres.vue';

export default {
  name: 'App',
  components: {
    CalculEncheres
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
