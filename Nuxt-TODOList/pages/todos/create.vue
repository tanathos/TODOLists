<template>
  <div class="xl:w-48">
    <div class="field">
      <label for="title">Title</label>
      <input id="title" v-model="newTodo.title" type="text" class="w-full">
    </div>
    <div class="field">
      <label for="title">Description</label>
      <textarea id="title" v-model="newTodo.description" class="w-full" />
    </div>

    <button id="createTodo" class="p-2" @click="onCreateClick">
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
      const res = await this.$axios.$post(`http://localhost:3000/todoapi/todos/`, { title: this.newTodo.title, description: this.newTodo.description });
      this.$router.push({ path: `/todos/${res.id}` });
    } catch (error) {
      console.error(error);
    }
  }
}
</script>

<style>

</style>
