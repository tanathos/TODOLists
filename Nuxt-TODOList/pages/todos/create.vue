<template>
  <div>
    <input v-model="newTodo.title" type="text">

    <button @click="onCreateClick">
      Create
    </button>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "nuxt-property-decorator";

@Component
export default class CreateTodo extends Vue {
  newTodo: any = { title: "" };

  async onCreateClick () {
    const res = await this.$axios.$post(``, { title: this.newTodo.title });

    console.log(res);
  }
}
</script>

<style>

</style>
