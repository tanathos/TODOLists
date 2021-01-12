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
    try {
      const res = await this.$axios.$post(`http://localhost:3000/todoapi/todos/`, { title: this.newTodo.title });
      this.$router.push({ path: `/todos/${res.id}` });
    } catch (error) {
      console.error(error);
    }
  }
}
</script>

<style>

</style>
