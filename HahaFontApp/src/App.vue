<template>
  <div id="app">
    <router-view/>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";

@Component({
  name: "app"
})
export default class App extends Vue {}
</script>

<style>
#app {
  height: 100%;
}
</style>
